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
                        using(var formMenu = new FormMenu(
                            formLogin.CurrentUser,
                            formLogin.IsGuest))
                        {
                            if(formMenu.ShowDialog() == DialogResult.Cancel)
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