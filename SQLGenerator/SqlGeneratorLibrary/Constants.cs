using System.Windows.Forms;

namespace SqlGeneratorLibrary
{
    public static class Constants
    {
        public static class Dialog
        {
            public static OpenFileDialog SelectFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\Desktop",
                Filter = "CSV Files (*.csv)|*.csv",
                CheckFileExists = true,
                CheckPathExists = true
            };
        }
    }
}
