using System.Windows.Forms;

namespace SqlGeneratorLibrary
{
    public static class Constants
    {
        public const string FileSelectionBasePath = @"C:\Desktop";
        public const string FileSelectionAcceptedFiles = "CSV Files (*.csv)|*.csv";

        public static class Dialog
        {
            public static OpenFileDialog SelectFileDialog = new OpenFileDialog
            {
                InitialDirectory = FileSelectionBasePath,
                Filter = FileSelectionAcceptedFiles,
                CheckFileExists = true,
                CheckPathExists = true
            };
        }
    }
}
