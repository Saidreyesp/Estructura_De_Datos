using System;
using System.Collections.Generic;

class VerificacionParentesis
{
    public static string VerificarBalance(string expresion)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in expresion)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0)
                    return "Fórmula no balanceada."; // Si la pila está vacía, no hay paréntesis de apertura correspondientes

                char apertura = pila.Pop();
                if ((c == ')' && apertura != '(') ||
                    (c == '}' && apertura != '{') ||
                    (c == ']' && apertura != '['))
                {
                    return "Fórmula no balanceada."; // Si no coinciden los paréntesis
                }
            }
        }

        return pila.Count == 0 ? "Fórmula balanceada." : "Fórmula no balanceada."; // Si la pila no está vacía, significa que faltan paréntesis de cierre
    }

    static void Main()
    {
        string expresion = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
        string resultado = VerificarBalance(expresion);
        Console.WriteLine(resultado);  // Solo imprime "Fórmula balanceada." o "Fórmula no balanceada."
    }
}
