using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace KDL_Task_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class MyUI : UIElement
    {
        //Ellipse el;
        public static List<Ellipse> allEllipse = new List<Ellipse>(100);
        public static int CountClickEllipse { get; set; }
        public static bool IsClick { get; set; } = false;
        public event EventHandler LeftEllipseClick;

        public void OnLeftEllipseClicked()
        {
            if (LeftEllipseClick != null)
                LeftEllipseClick(this, EventArgs.Empty);
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OnLeftEllipseClicked();
            if (sender is Ellipse  && ((Ellipse)sender).Fill != Brushes.Red && IsClick)
            {
               ((Ellipse)sender).Fill = Brushes.Red;
                CountClickEllipse++;
            }
        }

        public MyUI(Canvas canv)
        {
            Setter setter = new Setter();
            setter.Property = Shape.FillProperty;
            setter.Value = new SolidColorBrush(Colors.Red);

            Trigger trigger = new Trigger();
            trigger.Property = UIElement.IsMouseOverProperty;
            trigger.Value = true;
            trigger.Setters.Add(setter);



            Style ellipseStyle = new Style();
            ellipseStyle.Setters.Add(new Setter { Property = Shape.FillProperty, Value = new SolidColorBrush(Color.FromArgb(255,245,245,220))});
            ellipseStyle.Setters.Add(new Setter { Property = Shape.StrokeProperty, Value = new SolidColorBrush(Color.FromArgb(255, 139, 0, 0)) });
            ellipseStyle.Triggers.Add(trigger);

            for (int i = 0; i < 10; i++)
            {
                Circle.posY++;
                Circle.posX++;
                for (int iterator = 0; iterator < 10; iterator++)
                {
                    Ellipse el = new Ellipse();
                    el.Width = Circle.Width;
                    el.Height = Circle.Height;
                    el.Margin = new Thickness(Circle.posX * Circle.Width * 2, Circle.posY * Circle.Height * 2, 0, 0);
                    el.Style = ellipseStyle;
                    el.MouseLeftButtonDown += Ellipse_MouseLeftButtonDown;
                    allEllipse.Add(el);
                    canv.Children.Add(el);
                    Circle.posX++;
                }
                Circle.posX = 0;
            }
        }
    }
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = null;
        private int tick { get; set; } = 5;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (tick < 1)
            {
                timer.Stop();
                MyUI.IsClick = false;
                tick = 5;
                OutputTimeTextBlock.Text = $"Время вышло\nВы нажали {MyUI.CountClickEllipse} раз";
                RecordsPlayer();
                myButton.IsEnabled = true;
            }
            else
            {
                tick--;
                OutputTimeTextBlock.Text = $"Осталось {tick} секунд";
            }
         
        }
        private void MyButtonClick(object sender, EventArgs e)
        {
            foreach (var ellipse in MyUI.allEllipse)
            {
                ellipse.Fill = new SolidColorBrush(Color.FromRgb(245, 245, 220));
            }
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            OutputTimeTextBlock.Text = "";
            MyUI.CountClickEllipse = 0;
            MyUI.IsClick = true;
            ((Button)sender).IsEnabled = false;
            timer.Start();
        }

        private void WindowLoad(object sender, RoutedEventArgs e)
        {
            MyUI element = new MyUI(myCanvas);
            RecordsPlayer();
        }

        private void RecordsPlayer()
        {
            int countNodes = 0;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Records.xml");
  
            XmlElement xRoot = xDoc.DocumentElement;

            RecordsTextBlock.Text = "Ваши прошлые результаты";
            foreach (XmlNode xnode in xRoot)
            {
                RecordsTextBlock.Text += $"\n{xnode.InnerText}";
                countNodes++;      
            }

            if (countNodes < 5)
            {
                XmlElement clickElement = xDoc.CreateElement("countClick");
                XmlText clickElementText = xDoc.CreateTextNode($"{MyUI.CountClickEllipse}");
                clickElement.AppendChild(clickElementText);
                xRoot.AppendChild(clickElement);
            }
            else
            {
                XmlNode firstNode = xRoot.FirstChild;
                xRoot.RemoveChild(firstNode);

                XmlElement clickElement = xDoc.CreateElement("countClick");
                XmlText clickElementText = xDoc.CreateTextNode($"{MyUI.CountClickEllipse}");
                clickElement.AppendChild(clickElementText);
                xRoot.AppendChild(clickElement);
            }
            xDoc.Save("Records.xml");
        }
    }
}
