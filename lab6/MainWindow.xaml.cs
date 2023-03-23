using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Forms;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Point point;
        public Brush brush;
        public bool buttonClicked = false;
        public Rectangle currentRectangle;
        public MainWindow()
        {
            InitializeComponent();

            brush = Brushes.Red;
            Line line = new Line()
            {
                X1 = 10,
                Y1 = 10,
                X2 = 100,
                Y2 = 100,
                Stroke = brush,
                StrokeThickness = 5
            };
            canvas.Children.Add(line);
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                brush = new SolidColorBrush(Color.FromRgb(
                colorDialog.Color.R,
                colorDialog.Color.G,
                colorDialog.Color.B));
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentRectangle != null)
            {
                Point point = e.GetPosition(canvas);

                Rectangle rectangle = new Rectangle()
                {
                    Margin = new Thickness(point.X, point.Y, 5, 5),
                    Fill = brush,
                    Width = 10,
                    Height = 10
                };
                canvas.Children.Add(rectangle);
            }
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            point = e.GetPosition(this);

                currentRectangle = new Rectangle()
                {
                    Margin = new Thickness(point.X, point.Y, 5, 5),
                    Fill = brush,
                    Width = 10,
                    Height = 10
                };
                canvas.Children.Add(currentRectangle);
        }
        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            currentRectangle = null;
        }
    }
}
