namespace Lb2_4_Up_store
{
    internal static class Program
    {
        static void Main()
        {
            bool exitProgram = false;

            while (!exitProgram)
            {
                using(var formLogin = new FormLogin())
                {
                    if(formLogin.ShowDialog() == DialogResult.OK)
                    {
                        using(var formProducts = new FormProducts(
                            formLogin.CurrentUser,
                            formLogin.IsGuest))
                        {
                            if(formProducts.ShowDialog() == DialogResult.Cancel)
                            {
                                continue;
                            }
                            else
                            {
                                exitProgram = true;
                            }
                        }
                    }
                    else
                    {
                        exitProgram = true;
                    }
                }
            }
        }
    }
}