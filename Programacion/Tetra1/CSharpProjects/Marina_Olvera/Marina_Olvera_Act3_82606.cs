namespace Marina_Olvera
{
    public class Marina_Olvera_Act3_82606
    {
        public void CalculaPrecio()
        {
            bool isNumber;
            do
            {
                Console.Write("Ingrese precio : $");
                string? precioStr = Console.ReadLine();
                isNumber = int.TryParse(precioStr, out int precio);

                if (!string.IsNullOrEmpty(precioStr) && isNumber)
                {
                    double incremento;
                    if (precio < 1500)
                    {
                        incremento = precio * 0.11;
                    }
                    else
                    {
                        incremento = precio * 0.08;
                    }
                    int incrementoEntero = Convert.ToInt32(incremento);
                    Console.WriteLine($"El incremento es :${incrementoEntero}");
                    Console.WriteLine($"El nuevo precio es : ${incrementoEntero + precio}");
                }
                if (!isNumber)
                    Console.Clear();

            } while (!isNumber);
        }
    }
}
