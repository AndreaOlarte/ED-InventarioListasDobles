using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED___Programa_19.Listas_dobles
{
    class Inventario
    {
        private Producto _inicio;
        private Producto _fin;

        public void agregar(Producto producto)
        {
            if (_inicio == null)
            {
                _inicio = producto;
                _fin = producto;
            }
            else
            {
                _fin.siguiente = producto;
                producto.anterior = _fin;
                _fin = _fin.siguiente;
            }
        }

        public void agregarInicio(Producto producto)
        {
            producto.siguiente = _inicio;
            _inicio.anterior = producto;
            _inicio = producto;
        }

        public bool insertar(Producto producto, int posicion)
        {
            if (posicion == 0)
            {
                agregarInicio(producto);
                return true;
            }
            else
            {
                Producto auxiliar = _inicio;
                for (int i = 0; i < posicion - 1; i++)
                    auxiliar = auxiliar.siguiente;
                if (auxiliar != null && auxiliar.siguiente != null)
                {
                    producto.siguiente = auxiliar.siguiente; //Sólo cuando no es el último
                    auxiliar.siguiente.anterior = producto; //Sólo cuando no es el último
                    auxiliar.siguiente = producto;
                    producto.anterior = auxiliar;
                    return true;
                }
                else if (auxiliar != null)
                {
                    agregar(producto);
                    return true;
                }
                else
                    return false;
            }
        }

        public Producto buscar(string codigo)
        {
            Producto auxiliar = _inicio;
            while (auxiliar.siguiente != null && codigo != auxiliar.codigo)
                auxiliar = auxiliar.siguiente;
            if (auxiliar.codigo == codigo)
                return auxiliar;
            else
                return null;
        }

        public bool borrar(string codigo)
        {
            Producto auxiliar;
            if (_inicio.codigo == codigo)
            {
                _inicio = _inicio.siguiente;
                _inicio.anterior = null;
                return true;
            }
            else
            {
                auxiliar = buscar(codigo);
                if (auxiliar != null)
                {
                    auxiliar.anterior.siguiente = auxiliar.siguiente;
                    if (auxiliar.siguiente != null)
                        auxiliar.siguiente.anterior = auxiliar.anterior;
                    else
                        _fin = auxiliar.anterior;
                    return true;
                }
                else
                    return false;
            }
        }

        public bool borrarPrimero()
        {
            if (_inicio != null & _inicio.siguiente != null)
            {
                _inicio = _inicio.siguiente;
                _inicio.anterior = null;
                return true;
            }
            else
                return false;
        }

        public bool borrarUltimo()
        {
            if (_fin != null & _fin.anterior != null)
            {
                _fin = _fin.anterior;
                _fin.siguiente = null;
                return true;
            }
            else
                return false;
        }

        public string reporte()
        {
            if (_inicio == null)
                return "No hay productos";
            else
            {
                string cadena = "";
                Producto auxiliar = _inicio;
                while (auxiliar.siguiente != null)
                {
                    cadena += auxiliar.ToString() + Environment.NewLine;
                    auxiliar = auxiliar.siguiente;
                }
                cadena += auxiliar.ToString() + Environment.NewLine;
                return cadena;
            }
        }

        public string reporteInverso()
        {
            if (_fin == null)
                return "No hay productos";
            else
            {
                string cadena = "";
                Producto auxiliar = _fin;
                while (auxiliar.anterior != null)
                {
                    cadena += auxiliar.ToString() + Environment.NewLine;
                    auxiliar = auxiliar.anterior;
                }
                cadena += auxiliar.ToString() + Environment.NewLine;
                return cadena;
            }
        }
    }
}
