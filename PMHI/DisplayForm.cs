using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;

namespace PMHI
{
    public partial class DisplayForm : Form
    {
        private readonly IEnumerator<ShowModel> showModelsEnumerator;

        private readonly Stopwatch stopwatch = new Stopwatch();
        private readonly int zadanie;
        public List<LogObject> LogObjects = new();

        private Control displayControl;

        public DisplayForm(int zadanie,IEnumerable<ShowModel> showModels)
        {

            InitializeComponent();
            this.showModelsEnumerator = showModels.GetEnumerator();
            InitControl();
            displayControl.Click += DisplayControl_Click;
            this.zadanie = zadanie;
        }

        private void InitControl()
        {
            displayControl = new Panel()
            {
                BackColor = Color.Yellow,
            };
            this.Controls.Add(displayControl);
        }

        public void NextControlPostion()
        {
            showModelsEnumerator.MoveNext();
            if (showModelsEnumerator.Current == null)
            {
                this.Close();
                return;
            }
            SetControlparams(showModelsEnumerator.Current);
        }

        private void SetControlparams(ShowModel showModel)
        {
            Point position;
            Point farPoint;
            Point fixedposition;
            do
            {
                var angle = Random.Shared.Next(360);
                var mpoint = PointToClient(MousePosition);
                position = GetPosition(new Point(mpoint.X,mpoint.Y), angle , showModel.Range);
                fixedposition = PositionFix(angle, position, displayControl);

                farPoint = GetFarPoint(angle, position, displayControl);
                this.Text = $"x:{farPoint.x} y:{farPoint.y}, mx:{mpoint.X}my:{mpoint.Y}";

            } while (farPoint.x < 0 || farPoint.y < 0 || farPoint.x > this.ClientSize.Width || farPoint.y > this.ClientSize.Height ||
            fixedposition.x < 0 || fixedposition.y < 0 || fixedposition.x > this.ClientSize.Width || fixedposition.y > this.ClientSize.Height);


            displayControl.Left = fixedposition.x;
            displayControl.Top = fixedposition.y;
            displayControl.Size = new Size(showModel.Size, showModel.Size);
        }

        private Point GetFarPoint(double angle, Point point, Control control)
        {
            Point newpoint = point;
            if (angle >= 270)
            {
                newpoint = new Point(point.x + control.Size.Width , point.y);

            }
            else if (angle >= 180)
            {
                


            }
            else if (angle >= 90)
            {
                newpoint = new Point(point.x , point.y+control.Size.Height );

            }
            else
            {
                newpoint = new Point(point.x + control.Size.Width, point.y+ control.Size.Height);
            }
            return newpoint;
        }

        private void DisplayControl_Click(object? sender, EventArgs e)
        {
            stopwatch.Stop();
            LogObjects.Add(new LogObject(stopwatch.ElapsedTicks, showModelsEnumerator.Current));
            stopwatch.Restart();
            NextControlPostion();
        }

        public class Point
        {
            public int x;
            public int y;

            public Point(int x = 0, int y = 0)
            {
                this.x = x;
                this.y = y;
            }
        }

        public Point GetPosition(Point center, double angle, int range)
        {
            var point =
                new Point()
                {
                    x = (int)(center.x + (Math.Cos(angle * (Math.PI / 180)) * range)),
                    y = (int)(center.y + (Math.Sin(angle * (Math.PI / 180)) * range)),
                };

            return point;
        }

        private Point PositionFix(double angle, Point point, Control control)
        {
            Point newpoint = point;
            if (angle >= 270)
            {
                newpoint = new Point(point.x, point.y - control.Size.Height);

            }
            else if (angle>=180)
            {
                newpoint = new Point(point.x-control.Size.Width,point.y - control.Size.Height);

            }
            else if (angle >= 90) 
            {
                newpoint = new Point(point.x - control.Size.Width, point.y);
            }
            return newpoint;
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            stopwatch.Restart();
            showModelsEnumerator.MoveNext();
            SetControlparams(showModelsEnumerator.Current);
        }

        private void DisplayForm_Click(object sender, EventArgs e)
        {
            stopwatch.Restart();
            SetControlparams(showModelsEnumerator.Current);
        }

        private void DisplayForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void DisplayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var lines = new List<string>
            {
                "Ticks,Range,Size"
            };
            lines.AddRange( LogObjects.Select(x => $"{x.ElapsedTicks},{x.Range},{x.Size}"));
            File.WriteAllLines($"{zadanie}.csv", lines);
        }
    }
}