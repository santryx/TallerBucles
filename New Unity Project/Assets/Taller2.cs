using System.Collections;
using UnityEngine;

public class Taller2 : MonoBehaviour
{

    /*En esta clase se asignas la variable en booleano para CheckBox,se asigan una variable GameObjecto al grid 
     * como la red que se movera en los ejes Y y X para dar una posicion.*/

    public bool casillaCheckBox;
    public GameObject[,] grid;

    public void Start()
    {
        StartCoroutine(CreacionDeEsferas());
    }
    public IEnumerator CreacionDeEsferas()
    {
        /// se inicia el funcionamiento, empezar con el "if" para que empiece con el codigo cuando la casilla del checbox en el inspector este habilitada. De
        /// lo contrario imprimira en la consola que "no se ha habilitado el CheckBox", aparte de que desde aqui funciona el Random.Range para que le de un número 
        /// dentro del rango de a 12, ademas de que muestre en la consola la cantidad de esferas en alto y en ancho.

        if (casillaCheckBox == true)
        {

            int ancho = Random.Range(3, 12);
            int alto = Random.Range(3, 12);

            Debug.Log("Número de esferas de ancho es: " + ancho);
            Debug.Log("Número de esferas de alto es: " + alto);
            Debug.Log("total Esferas: " + ancho * alto);

            grid = new GameObject[ancho, alto];

            for (int x = 0; x < ancho; x++)
            {

                for (int y = 0; y < alto; y++)
                {

                    /* desde los "for" empezara la funcion en bucle hasta que cumpla la funcion logica inidicando en Cero y con un contador que va ir +1 en cada iteracion hasta 
                     * que llegue al numero que arrojo el random, ademas de la asignacion del un Gameobject desde "PrimitiveType.Sphere", como refenrente para que
                     * haga los clones solicitados de acuerdo con la cantidad Random desde el rango  del 3 al 12 se encuentra el codigo con las iteraciones que hara que clone el 
                     * Gameobjet de esfera seleccionado en el inspector y que lo coloque gracias al acomulador en una posicion de +1 en el eje X y en el eje Y, para que de esta 
                     * manera cree filas y columnas en orden, tambien se le da a cada esfera un color aletario en cada iteracion desde una funcion con "Switch" */

                    GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Vector3 position = new Vector3(x, y, 0);
                    go.transform.position = position;
                    grid[x, y] = go;

                    go.GetComponent<Renderer>().material.color = ColorAleatorio();

                    yield return new WaitForSeconds(0.2f);

                    GameObject goC = grid[x, y];
                    int a = x - 1;
                    int b = y;

                    if (a >= 0 && a < ancho - 1)
                    {

                        /* se crean una varibles basadas en X y Y para que que tome una dentro de la funcion que compare las esferas continuas en fila enviado informacion de dos variables
                         * que serviran de acomulador de cada esfera se pueda compara con la siguiente, para que en caso de que de que sean de igual color sean reemplazados por esferas de color negro, esto se 
                         * logra debido a que se crea una nueva clase que hara la iteraciones de comparar las esferas y llamandola retornara los resultados */

                        Comparar comparar = new Comparar();
                        GameObject goB = grid[a, b];
                        comparar.previo = goB.GetComponent<Renderer>().material.color;
                        comparar.actual = goC.GetComponent<Renderer>().material.color;
                        goB.GetComponent<Renderer>().material.color = comparar.ColorPrevio(comparar.previo, comparar.actual);
                        goC.GetComponent<Renderer>().material.color = comparar.ColorActual(comparar.previo, comparar.actual);

                    }
                }
            }
        }

        else
        {

            Debug.Log("No se Habilito el CheckBox");

        }
    }

    public Color ColorAleatorio()
    {
        /* funcion que retornara un color al azar cada vez que el bucle la llame en cada iteracion de este */

        Color colorRandom = Color.clear;
        int colorN = Random.Range(0, 6);
        switch (colorN)
        {

            case 0:
                colorRandom = Color.blue;
                break;
            case 1:
                colorRandom = Color.gray;
                break;

            case 2:
                colorRandom = Color.red;
                break;
            case 3:
                colorRandom = Color.green;
                break;
            case 4:
                colorRandom = Color.cyan;
                break;
            case 5:
                colorRandom = Color.yellow;
                break;
            case 6:
                colorRandom = Color.white;
                break;

        }

        return colorRandom;

    }

    /* Creacion de una nueva clase, con la funciones que comparara los colores de las esferas, al ser de igual color, esta retornara al la iteracion que llama la funcion  un cambio de color, 
     * para que ambas sean negras, y de este mundo cumpla con el objetivo, en caso de que no sean del mismo color esta funcion no retornara nada y dejara las esferas con el color 
     * con el que se crearon en cada iteración*/
    public class Comparar
    {

        public Color previo = Color.clear;
        public Color actual = Color.clear;

        public Color ColorActual(Color previo, Color actual)
        {

            Color colorVerificado = actual;
            Color colorduplicado = Color.black;

            if (previo == actual)
            {

                colorVerificado = colorduplicado;

            }

            return colorVerificado;

        }

        public Color ColorPrevio(Color previo, Color actual)
        {

            Color colorVerificado = previo;
            Color colorduplicado = Color.black;

            if (previo == actual)
            {

                colorVerificado = colorduplicado;

            }

            return colorVerificado;

        }
    }
}


