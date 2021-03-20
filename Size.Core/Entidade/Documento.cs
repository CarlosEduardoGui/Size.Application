using Size.Core.Enums;
using System;
using System.Collections.Generic;

namespace Size.Core.Entidade
{
    public class Documento
    {
        public Guid ID { get; private set; }
        public ETipoDocumento TipoDocumento { get; private set; }
        public string Numero { get; private set; }


        public Documento() { }

        public static Documento NovoDocumento(string pDocumento)
        {
            ValidarDocumento(pDocumento);

            return new Documento
            {
                ID = Guid.NewGuid(),
                Numero = pDocumento,
                TipoDocumento = VerificarTipoDocumento(pDocumento) == 11 ? ETipoDocumento.CPF : ETipoDocumento.CNPJ
            };

        }

        private static int VerificarTipoDocumento(string pDocumento)
        {
            var lDocumentoNumeros = ApenasNumeros(pDocumento);
            return lDocumentoNumeros.Length == 11
                ? 11
                : lDocumentoNumeros.Length == 14
                ? 14
                : throw new Exception("Tamanho de Documento inválido.");
        }

        #region Validador Documento
        private static void ValidarDocumento(string pDocumento)
        {
            if (string.IsNullOrEmpty(pDocumento)) throw new Exception("Documento está em branco ou está nulo");

            if (!Validar(pDocumento, VerificarTipoDocumento(pDocumento))) throw new Exception("Documento inválido.");
        }

        private static string ApenasNumeros(string pValor)
        {
            var lSomenteNumero = "";
            foreach (var lValor in pValor)
            {
                if (char.IsDigit(lValor))
                {
                    lSomenteNumero += lValor;
                }
            }
            return lSomenteNumero.Trim();
        }

        private static bool Validar(string pDocumento, int pTamanhoDocumento)
        {
            var lNumeros = ApenasNumeros(pDocumento);

            return TemDigitosValidos(lNumeros, pTamanhoDocumento);
        }

        private static bool TemDigitosValidos(string pValor, int pTamanhoDocumento)
        {
            var lNumero = pValor.Substring(0, pValor.Length - 2);

            DigitoVerificador lDigitoVerificador;
            if (pTamanhoDocumento == 11)
                lDigitoVerificador = new DigitoVerificador(lNumero)
                    .ComMultiplicadoresDeAte(2, 11)
                    .Substituindo("0", 10, 11);
            else
                lDigitoVerificador = new DigitoVerificador(lNumero)
                        .ComMultiplicadoresDeAte(2, 9)
                        .Substituindo("0", 10, 11);

            var lPrimeiroDigito = lDigitoVerificador.CalculaDigito();
            lDigitoVerificador.AddDigito(lPrimeiroDigito);
            var lSegundoDigito = lDigitoVerificador.CalculaDigito();

            return string.Concat(lPrimeiroDigito, lSegundoDigito) == pValor.Substring(pValor.Length - 2, 2);
        }

        private class DigitoVerificador
        {
            private string _numero;
            private const int Modulo = 11;
            private readonly List<int> _multiplicadores = new() { 2, 3, 4, 5, 6, 7, 8, 9 };
            private readonly IDictionary<int, string> _substituicoes = new Dictionary<int, string>();
            private bool _complementarDoModulo = true;

            public DigitoVerificador(string pNumero)
            {
                _numero = pNumero;
            }

            public DigitoVerificador ComMultiplicadoresDeAte(int pPrimeiroMultiplicador, int pUltimoMultiplicador)
            {
                _multiplicadores.Clear();
                for (var i = pPrimeiroMultiplicador; i <= pUltimoMultiplicador; i++)
                    _multiplicadores.Add(i);

                return this;
            }

            public DigitoVerificador Substituindo(string pSubstituto, params int[] pDigitos)
            {
                foreach (var i in pDigitos)
                {
                    _substituicoes[i] = pSubstituto;
                }
                return this;
            }

            public void AddDigito(string pDigito)
            {
                _numero = string.Concat(_numero, pDigito);
            }

            public string CalculaDigito()
            {
                return !(_numero.Length > 0) ? "" : GetDigitSum();
            }

            private string GetDigitSum()
            {
                var lSoma = 0;
                for (int i = _numero.Length - 1, m = 0; i >= 0; i--)
                {
                    var lProduto = (int)char.GetNumericValue(_numero[i]) * _multiplicadores[m];
                    lSoma += lProduto;

                    if (++m >= _multiplicadores.Count)
                        m = 0;
                }

                var lMod = lSoma % Modulo;
                var lResultado = _complementarDoModulo ? Modulo - lMod : lMod;

                return _substituicoes.ContainsKey(lResultado) ? _substituicoes[lResultado] : lResultado.ToString();
            }
        }

        #endregion
    }
}
