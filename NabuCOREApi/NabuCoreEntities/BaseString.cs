using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities
{
    [DataContract]
    public class BaseString : BaseType
    {
        [DataMember]
        public string Value { get; set; }

        public BaseString() : base()
        {
        }
        
        public BaseString(string pValue) : base()
        {
            Value = pValue;
        }

        public void ProcessOutSpeechMarks(string pSeparator)
        {
            if (Value != null && Value.Length > 0)
            {
                // do we have speech
                if (Value.Contains("\""))
                {
                    string dataWithoutSpeechMarks = "";
                    for (int i = 0; i < Value.Length; i++)
                    {
                        // if this is speech mark
                        if (Value[i] == Char.Parse("\""))
                        {
                            // step past the speech mark
                            for (int j = i + 1; j < Value.Length; j++)
                            {
                                // if its not the separator then copy it forw
                                if (Value[j] != Char.Parse(pSeparator))
                                {
                                    // if this is the closing speech mark
                                    if (Value[j] == Char.Parse("\""))
                                    {
                                        i = j;
                                        break;
                                    }
                                    else
                                    {
                                        dataWithoutSpeechMarks += Value[j];
                                    }
                                }
                                else
                                {
                                    // don't copy forward the separator character
                                }
                            }
                        }
                        else
                            dataWithoutSpeechMarks += Value[i];
                    }
                    Value = dataWithoutSpeechMarks;
                }
            }
        }

        public string[] GetFields()
        {
            return GetFields("|");
        }
        public string[] GetFields(string pSeparator)
        {
            string pipeSeparator = pSeparator;

            if (Value != null && Value.Length > 0)
            {
                List<string> fields = new List<string>();
                string field = "";
                for (int i = 0; i < Value.Length; i++)
                {
                    // is this a separator character
                    if (Value[i] == pipeSeparator[0])
                    {
                        fields.Add(field);
                        field = "";
                    }
                    else
                    {
                        if (Value[i] == Char.Parse("'"))
                        {
                            field += Value[i];
                            i++;
                            for (; i < Value.Length; i++)
                            {
                                if (Value[i] == Char.Parse("'"))
                                    break;
                                else
                                    field += Value[i];
                            }
                            if (Value[i] == Char.Parse("'"))
                                field += Value[i];
                        }
                        else
                            field += Value[i];
                    }
                }
                fields.Add(field);
                return fields.ToArray();
            }
            else
                return Value.Split(pipeSeparator.ToCharArray());
        }
    }
}
