using System;
using System.Linq;
using NetEti.Globals;
using System.Collections.Generic;

namespace NetEti.ApplicationEnvironment
{
    /// <summary>
    /// Zugriffe auf Kommandozeilen-Parameter<br></br>
    ///           Implementiert IGetStringValue.
    ///           Minimal-Funktionalität:<br></br>
    ///           Wenn der übergebene Key in der Kommandozeile existiert,
    ///           wird dieser unverändert zurückggegeben, ansonsten der
    ///           Default Value.
    ///           Ist der übergebene Key numerisch, wird versucht, mit
    ///           ihm als Index in die Kommandozeilenparameter zu greifen;
    ///           Bei Erfolg wird der entsprechende Wert zurückgegeben,
    ///           ansonsten der Default Value.
    /// </summary>
    /// <remarks>
    /// File: CommandLineAccess.cs<br></br>
    /// Autor: Erik Nagel, NetEti<br></br>
    ///<br></br>
    /// 13.03.2012 Erik Nagel: erstellt<br></br>
    /// 04.06.2014 Erik Nagel: Auflösen benannter Parameter (/Name=xyz oder -Name=xyz)<br></br>
    /// 10.04.2020 Erik Nagel: Bei Auflösung nach numerischem Key (Positionsnummer des Arguments)
    /// Parameter mit vorangestellten '/' oder '-' ausgeschlossen.<br></br>
    /// </remarks>
    public class CommandLineAccess : IGetStringValue
    {
        #region IGetStringValue Members

        /// <summary>
        /// Liefert genau einen Wert zu einem Key. Wenn es keinen Wert zu dem
        /// Key gibt, wird defaultValue zurückgegeben.
        /// </summary>
        /// <param name="key">Der Zugriffsschlüssel (string)</param>
        /// <param name="defaultValue">Das default-Ergebnis (string)</param>
        /// <returns>Der Ergebnis-String</returns>
        public string GetStringValue(string key, string defaultValue)
        {
            string rtn = defaultValue;
            List<string> args = new List<string>();
            if (this._commandLineArgs != null)
            {
                foreach (string arg in this._commandLineArgs)
                {
                    string subArg;
                    if (arg.StartsWith("/") || arg.StartsWith("-"))
                    {
                        subArg = arg.Substring(1);
                        if (subArg.StartsWith("-"))
                        {
                            subArg = subArg.Substring(1);
                        }
                    }
                    else
                    {
                        subArg = arg;
                    }
                    if (subArg.ToUpper().StartsWith(key.ToUpper()))
                    {
                        if (subArg.Length > key.Length)
                        {
                            if ((new string[] { ":", "=" }).Contains(subArg.Substring(key.Length, 1)))
                            {
                                rtn = subArg.Substring(key.Length + 1);
                            }
                        }
                        if (rtn == defaultValue && subArg.ToUpper().Equals(key.ToUpper()))
                        {
                            rtn = key;
                        }
                    }
                }
                if (rtn == defaultValue)
                {
                    int cmdIndex;
                    if (Int32.TryParse(key, out cmdIndex) && this._commandLineArgs.Length > cmdIndex)
                    {
                        string rtnCandidate = this._commandLineArgs[cmdIndex];
                        if (!(rtnCandidate.StartsWith("/") || rtnCandidate.StartsWith("-")))
                        {
                            rtn = rtnCandidate;
                        }
                    }
                }
            }
            return rtn;
        }

        /// <summary>
        /// Liefert ein string-Array zu einem Key. Wenn es keinen Wert zu dem
        /// Key gibt, wird defaultValue zurückgegeben.
        /// Liefert nur einen Einzelwert als Array verpackt, muss ggf. spaeter
        /// erweitert werden.
        /// </summary>
        /// <param name="key">Der Zugriffsschlüssel (string)</param>
        /// <param name="defaultValues">Das default-Ergebnis (string[])</param>
        /// <returns>Das Ergebnis-String-Array</returns>
        public string[] GetStringValues(string key, string[] defaultValues)
        {
            string rtn = GetStringValue(key, null);
            if (rtn != null)
            {
                return new string[] { rtn };
            }
            else
            {
                return defaultValues;
            }
        }

        /// <summary>
        /// Liefert einen beschreibenden Namen dieses StringValueGetters,
        /// z.B. Name plus ggf. Quellpfad.
        /// </summary>
        public string Description { get; set; }

        #endregion IGetStringValue Members

        #region public members

        /// <summary>
        /// Konstruktor - setzt den internen Reader
        /// </summary>
        public CommandLineAccess()
        {
            this.Description = "Kommandozeile";
            if (AppDomain.CurrentDomain.SetupInformation.ActivationArguments != null)
            {
                this._commandLineArgs = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData;
            }
            else
            {
                this._commandLineArgs = Environment.GetCommandLineArgs();
            }
        }

        #endregion public members

        #region private members

        private string[] _commandLineArgs;

        #endregion private members

    }
}
