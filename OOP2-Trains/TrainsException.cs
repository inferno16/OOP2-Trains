using System;
using System.Windows.Forms;

namespace OOP2_Trains
{
    class TrainsException
    {
        internal static void ShowDefault(Form form, Exception ex)
        {
            MessageBox.Show("Възникна неочаквана грешка, моля опитайте отново!\n" + Environment.NewLine +
                        "Ако проблемът остане моля свържете се с поддръжката" + Environment.NewLine +
                        "Код на грешката: 0x" + ex.HResult.ToString("X8").ToUpper());
            form.Close();
        }
    }
}
