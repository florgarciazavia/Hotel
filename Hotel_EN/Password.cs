using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_EN
{
    class Password
    {
        public int CambioContraseña(int inten, int contra, int nro, int val)
        {
            while (inten < 3)
            {
                Console.WriteLine("Enter your password");
                nro = Convert.ToInt32(Console.ReadLine());
                if (contra == nro)
                {
                    Console.WriteLine("Enter your new password");
                    Console.WriteLine("(You must use numbers)");
                    nro = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Repeat your new password");
                    val = Convert.ToInt32(Console.ReadLine());
                    if (nro == val)
                    {
                        contra = nro;
                        Console.WriteLine("Password has been changed successfully");
                        inten = 3;
                    }
                    else
                    {
                        Console.WriteLine("Operation failed");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong password");
                    inten += 1;
                }
            }
            return contra;
        }

        public Boolean Ingreso(Boolean acceder, int contra, int nro, int inten)
        {
            acceder = false;
            while (inten < 3)
            {
                Console.WriteLine("Enter your password to access");
                nro = Convert.ToInt32(Console.ReadLine());
                if (contra == nro)
                {
                    acceder = true;
                    inten = 3;
                }
                else
                {
                    Console.WriteLine("Wrong password");
                    inten += 1;
                }
            }
            return acceder;
        }
    }
}
