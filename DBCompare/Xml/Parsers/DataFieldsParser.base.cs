

#region using statements

using DataJuggler.Net7;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using XmlMirror.Runtime7.Objects;
using XmlMirror.Runtime7.Util;

#endregion

namespace DBCompare.Xml.Parsers
{

    #region class DataFieldsParser : ParserBaseClass
    /// <summary>
    /// This class is used to parse 'DataField' objects.
    /// </summary>
    public partial class DataFieldsParser : ParserBaseClass
    {

        #region Methods

            #region LoadDataFields(string sourceXmlText)
            /// <summary>
            /// This method is used to load a list of 'DataField' objects.
            /// </summary>
            /// <param name="sourceXmlText">The source xml to be parsed.</param>
            /// <returns>A list of 'DataField' objects.</returns>
            public List<DataField> LoadDataFields(string sourceXmlText)
            {
                // initial value
                List<DataField> dataFields = null;

                // if the source text exists
                if (TextHelper.Exists(sourceXmlText))
                {
                    // create an instance of the parser
                    XmlParser parser = new XmlParser();

                    // Create the XmlDoc
                    this.XmlDoc = parser.ParseXmlDocument(sourceXmlText);

                    // If the XmlDoc exists and has a root node.
                    if ((this.HasXmlDoc) && (this.XmlDoc.HasRootNode))
                    {
                        // parse the dataFields
                        dataFields = ParseDataFields(this.XmlDoc.RootNode);
                    }
                }

                // return value
                return dataFields;
            }
            #endregion

            #region ParseDataField(ref DataField dataField, XmlNode xmlNode)
            /// <summary>
            /// This method is used to parse DataField objects.
            /// </summary>
            public DataField ParseDataField(ref DataField dataField, XmlNode xmlNode)
            {
                // if the dataField object exists and the xmlNode exists
                if ((dataField != null) && (xmlNode != null))
                {
                    // get the full name of this node
                    string fullName = xmlNode.GetFullName();

                    // Check the name of this node to see if it is mapped to a property
                    switch(fullName)
                    {
                        case "Database.Tables.DataTable.Fields.DataField.DataType":

                            // Set the value for dataField.DataType
                            dataField.DataType = EnumHelper.GetEnumValue<DataJuggler.Net7.DataManager.DataTypeEnum>(xmlNode.FormattedNodeValue, DataJuggler.Net7.DataManager.DataTypeEnum.NotSupported);

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.DBDataType":

                            // Set the value for dataField.DBDataType
                            dataField.DBDataType = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.DBFieldName":

                            // Set the value for dataField.DBFieldName
                            dataField.DBFieldName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.DecimalPlaces":

                            // Set the value for dataField.DecimalPlaces
                            dataField.DecimalPlaces = NumericHelper.ParseInteger(xmlNode.FormattedNodeValue, 0, -1);

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.DefaultValue":

                            // Set the value for dataField.DefaultValue
                            dataField.DefaultValue = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.EnumDataTypeName":

                            // Set the value for dataField.EnumDataTypeName
                            dataField.EnumDataTypeName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.FieldName":

                            // Set the value for dataField.FieldName
                            dataField.FieldName = xmlNode.FormattedNodeValue;

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.HasDefault":

                            // Set the value for dataField.HasDefault
                            dataField.HasDefault = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.IsAutoIncrement":

                            // Set the value for dataField.IsAutoIncrement
                            dataField.IsAutoIncrement = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.IsEnumeration":

                            // Set the value for dataField.IsEnumeration
                            dataField.IsEnumeration = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.IsNullable":

                            // Set the value for dataField.IsNullable
                            dataField.IsNullable = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.IsReadOnly":

                            // Set the value for dataField.IsReadOnly
                            dataField.IsReadOnly = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.Precision":

                            // Set the value for dataField.Precision
                            dataField.Precision = NumericHelper.ParseInteger(xmlNode.FormattedNodeValue, 0, -1);

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.PrimaryKey":

                            // Set the value for dataField.PrimaryKey
                            dataField.PrimaryKey = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.Required":

                            // Set the value for dataField.Required
                            dataField.Required = BooleanHelper.ParseBoolean(xmlNode.FormattedNodeValue, false, false);

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.Scale":

                            // Set the value for dataField.Scale
                            dataField.Scale = NumericHelper.ParseInteger(xmlNode.FormattedNodeValue, 0, -1);

                            // required
                            break;

                        case "Database.Tables.DataTable.Fields.DataField.Size":

                            // Set the value for dataField.Size
                            dataField.Size = NumericHelper.ParseInteger(xmlNode.FormattedNodeValue, 0, -1);

                            // required
                            break;

                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                         foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // append to this DataField
                            dataField = ParseDataField(ref dataField, childNode);
                        }
                    }
                }

                // return value
                return dataField;
            }
            #endregion

            #region ParseDataFields(XmlNode xmlNode, List<DataField> dataFields = null)
            /// <summary>
            /// This method is used to parse a list of 'DataField' objects.
            /// </summary>
            /// <param name="XmlNode">The XmlNode to be parsed.</param>
            /// <returns>A list of 'DataField' objects.</returns>
            public List<DataField> ParseDataFields(XmlNode xmlNode, List<DataField> dataFields = null)
            {
                // locals
                DataField dataField = null;
                bool cancel = false;

                // if the xmlNode exists
                if (xmlNode != null)
                {
                    // get the full name for this node
                    string fullName = xmlNode.GetFullName();

                    // if this is the new collection line
                    if (fullName == "Database.Tables.DataTable.Fields")
                    {
                        // Raise event Parsing is starting.
                        cancel = Parsing(xmlNode);

                        // If not cancelled
                        if (!cancel)
                        {
                            // create the return collection
                            dataFields = new List<DataField>();
                        }
                    }
                    // if this is the new object line and the return collection exists
                    else if ((fullName == "Database.Tables.DataTable.Fields.DataField") && (dataFields != null))
                    {
                        // Create a new object
                        dataField = new DataField();

                        // Perform pre parse operations
                        cancel = Parsing(xmlNode, ref dataField);

                        // If not cancelled
                        if (!cancel)
                        {
                            // parse this object
                            dataField = ParseDataField(ref dataField, xmlNode);
                        }

                        // Perform post parse operations
                        cancel = Parsed(xmlNode, ref dataField);

                        // If not cancelled
                        if (!cancel)
                        {
                            // Add this object to the return value
                            dataFields.Add(dataField);
                        }
                    }

                    // if there are ChildNodes
                    if (xmlNode.HasChildNodes)
                    {
                        // iterate the child nodes
                        foreach(XmlNode childNode in xmlNode.ChildNodes)
                        {
                            // self call this method for each childNode
                            dataFields = ParseDataFields(childNode, dataFields);
                        }
                    }
                }

                // return value
                return dataFields;
            }
            #endregion

        #endregion

    }
    #endregion

}
