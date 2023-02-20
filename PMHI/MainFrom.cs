namespace PMHI
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rangeArray = new List<int>() { 0, 20, 40, 60, 100, 150, 200, 250, 300, 350 };
            var sizeArray = new List<int>() { 10 };
            var iterations = 5;
            List<ShowModel> list = GenSequence(rangeArray,sizeArray,iterations);
            var form = new DisplayForm(1,list);
            form.Show();
        }

        private static List<ShowModel> GenSequence(List<int> rangeArray,List<int> sizeArray,int iterations)
        {
          
            var list = new List<ShowModel>();

            foreach (var range in rangeArray)
            {
                foreach (var size in sizeArray)
                {
                    for (int i = 0; i < iterations; i++)
                    {

                        list.Add(new ShowModel { Range = range, Size = size });
                    }
                }
            }
            list = list.OrderBy(x => Random.Shared.Next()).ToList();
            return list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var rangeArray = new List<int>() { 400 };
            var sizeArray = new List<int>() { 8, 10, 12, 15, 20, 30, 40, 50, 70, 100 };
            var iterations = 5;
            List<ShowModel> list = GenSequence(rangeArray, sizeArray, iterations);
            var form = new DisplayForm(2,list);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var rangeArray = new List<int>() { 0, 20, 40, 60, 100, 150, 200, 250, 300, 350};
            var sizeArray = new List<int>() { 8, 10, 12, 15, 20, 30, 40, 50, 70, 100 };
            var iterations = 3;
            List<ShowModel> list = GenSequence(rangeArray, sizeArray, iterations);
            var form = new DisplayForm(3,list);
            form.Show();
        }
    }
}