"use strict";
var Asset = (function () {
    function Asset(DeckType, Id, InspectionDate, InspectionNumber, IsHighwayBridge, IsMaintenanceRequired, Name, Owner, StructureNumber) {
        this.DeckType = DeckType;
        this.Id = Id;
        this.InspectionDate = InspectionDate;
        this.InspectionNumber = InspectionNumber;
        this.IsHighwayBridge = IsHighwayBridge;
        this.IsMaintenanceRequired = IsMaintenanceRequired;
        this.Name = Name;
        this.Owner = Owner;
        this.StructureNumber = StructureNumber;
    }
    return Asset;
}());
exports.Asset = Asset;
