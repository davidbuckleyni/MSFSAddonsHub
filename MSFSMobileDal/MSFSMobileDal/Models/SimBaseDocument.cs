using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddons.Models
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("SimBase.Document", Namespace = "", IsNullable = false)]
 
        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
         public partial class SimBaseDocument
        {

            private string descrField;

            private SimBaseDocumentFlightPlanFlightPlan flightPlanFlightPlanField;

            private string typeField;

            private string versionField;

            /// <remarks/>
            public string Descr
            {
                get
                {
                    return this.descrField;
                }
                set
                {
                    this.descrField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("FlightPlan.FlightPlan")]
            public SimBaseDocumentFlightPlanFlightPlan FlightPlanFlightPlan
            {
                get
                {
                    return this.flightPlanFlightPlanField;
                }
                set
                {
                    this.flightPlanFlightPlanField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Type
            {
                get
                {
                    return this.typeField;
                }
                set
                {
                    this.typeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string version
            {
                get
                {
                    return this.versionField;
                }
                set
                {
                    this.versionField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class SimBaseDocumentFlightPlanFlightPlan
        {

            private string titleField;

            private string fPTypeField;

            private string routeTypeField;

            private ushort cruisingAltField;

            private string departureIDField;

            private string departureLLAField;

            private string destinationIDField;

            private string destinationLLAField;

            private string descrField;

            private string departureNameField;

            private string destinationNameField;

            private SimBaseDocumentFlightPlanFlightPlanAppVersion appVersionField;

            private SimBaseDocumentFlightPlanFlightPlanATCWaypoint[] aTCWaypointField;

            /// <remarks/>
            public string Title
            {
                get
                {
                    return this.titleField;
                }
                set
                {
                    this.titleField = value;
                }
            }

            /// <remarks/>
            public string FPType
            {
                get
                {
                    return this.fPTypeField;
                }
                set
                {
                    this.fPTypeField = value;
                }
            }

            /// <remarks/>
            public string RouteType
            {
                get
                {
                    return this.routeTypeField;
                }
                set
                {
                    this.routeTypeField = value;
                }
            }

            /// <remarks/>
            public ushort CruisingAlt
            {
                get
                {
                    return this.cruisingAltField;
                }
                set
                {
                    this.cruisingAltField = value;
                }
            }

            /// <remarks/>
            public string DepartureID
            {
                get
                {
                    return this.departureIDField;
                }
                set
                {
                    this.departureIDField = value;
                }
            }

            /// <remarks/>
            public string DepartureLLA
            {
                get
                {
                    return this.departureLLAField;
                }
                set
                {
                    this.departureLLAField = value;
                }
            }

            /// <remarks/>
            public string DestinationID
            {
                get
                {
                    return this.destinationIDField;
                }
                set
                {
                    this.destinationIDField = value;
                }
            }

            /// <remarks/>
            public string DestinationLLA
            {
                get
                {
                    return this.destinationLLAField;
                }
                set
                {
                    this.destinationLLAField = value;
                }
            }

            /// <remarks/>
            public string Descr
            {
                get
                {
                    return this.descrField;
                }
                set
                {
                    this.descrField = value;
                }
            }

            /// <remarks/>
            public string DepartureName
            {
                get
                {
                    return this.departureNameField;
                }
                set
                {
                    this.departureNameField = value;
                }
            }

            /// <remarks/>
            public string DestinationName
            {
                get
                {
                    return this.destinationNameField;
                }
                set
                {
                    this.destinationNameField = value;
                }
            }

            /// <remarks/>
            public SimBaseDocumentFlightPlanFlightPlanAppVersion AppVersion
            {
                get
                {
                    return this.appVersionField;
                }
                set
                {
                    this.appVersionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ATCWaypoint")]
            public SimBaseDocumentFlightPlanFlightPlanATCWaypoint[] ATCWaypoint
            {
                get
                {
                    return this.aTCWaypointField;
                }
                set
                {
                    this.aTCWaypointField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class SimBaseDocumentFlightPlanFlightPlanAppVersion
        {

            private byte appVersionMajorField;

            private uint appVersionBuildField;

            /// <remarks/>
            public byte AppVersionMajor
            {
                get
                {
                    return this.appVersionMajorField;
                }
                set
                {
                    this.appVersionMajorField = value;
                }
            }

            /// <remarks/>
            public uint AppVersionBuild
            {
                get
                {
                    return this.appVersionBuildField;
                }
                set
                {
                    this.appVersionBuildField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class SimBaseDocumentFlightPlanFlightPlanATCWaypoint
        {

            private string aTCWaypointTypeField;

            private string worldPositionField;

            private byte runwayNumberFPField;

            private bool runwayNumberFPFieldSpecified;

            private SimBaseDocumentFlightPlanFlightPlanATCWaypointICAO iCAOField;

            private string idField;

            /// <remarks/>
            public string ATCWaypointType
            {
                get
                {
                    return this.aTCWaypointTypeField;
                }
                set
                {
                    this.aTCWaypointTypeField = value;
                }
            }

            /// <remarks/>
            public string WorldPosition
            {
                get
                {
                    return this.worldPositionField;
                }
                set
                {
                    this.worldPositionField = value;
                }
            }

            /// <remarks/>
            public byte RunwayNumberFP
            {
                get
                {
                    return this.runwayNumberFPField;
                }
                set
                {
                    this.runwayNumberFPField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool RunwayNumberFPSpecified
            {
                get
                {
                    return this.runwayNumberFPFieldSpecified;
                }
                set
                {
                    this.runwayNumberFPFieldSpecified = value;
                }
            }

            /// <remarks/>
            public SimBaseDocumentFlightPlanFlightPlanATCWaypointICAO ICAO
            {
                get
                {
                    return this.iCAOField;
                }
                set
                {
                    this.iCAOField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class SimBaseDocumentFlightPlanFlightPlanATCWaypointICAO
        {

            private string iCAOIdentField;

            /// <remarks/>
            public string ICAOIdent
            {
                get
                {
                    return this.iCAOIdentField;
                }
                set
                {
                    this.iCAOIdentField = value;
                }
            }
        }


    }
 