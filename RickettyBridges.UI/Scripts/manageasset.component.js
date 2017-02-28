"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var forms_1 = require('@angular/forms');
var asset_1 = require('./asset');
var decktype_1 = require('./decktype');
var asset_service_1 = require('./asset-service');
var ManageAssetComponent = (function () {
    function ManageAssetComponent(assetService, fb) {
        this.assetService = assetService;
        this.fb = fb;
        this.formattedInspectionDate = '';
        this.createForm();
    }
    ManageAssetComponent.prototype.createForm = function () {
        this.assetForm = this.fb.group({
            inspectionNo: ['', forms_1.Validators.required],
            inspectionDate: ['', forms_1.Validators.required],
            structureNo: '',
            deckType: '',
            maintenanceReq: '',
            highwayBridge: ''
        });
    };
    ManageAssetComponent.prototype.ngOnInit = function () {
        this.getVersion();
        //this.getAsset();
        this.getDeckTypes();
    };
    ManageAssetComponent.prototype.revert = function () { this.ngOnChanges(); };
    ManageAssetComponent.prototype.ngOnChanges = function () {
        this.assetForm.reset({
            inspectionNo: this.model.InspectionNumber,
            inspectionDate: this.model.InspectionDate,
            structureNo: this.model.StructureNumber,
            deckType: this.model.DeckType,
            //deckType: new DeckType(this.model.DeckType.Id, this.model.DeckType.Value)
            maintenanceReq: this.model.IsMaintenanceRequired,
            highwayBridge: this.model.IsHighwayBridge
        });
    };
    ManageAssetComponent.prototype.getAsset = function (id) {
        var _this = this;
        this.assetService.getAsset(id)
            .subscribe(function (model) { return _this.model = model; }, function (error) { return _this.errorMessage = error; });
    };
    ManageAssetComponent.prototype.getDeckTypes = function () {
        var _this = this;
        this.assetService.getDeckTypes()
            .subscribe(function (deckTypes) { return _this.deckTypes = deckTypes; }, function (error) { return _this.errorMessage = error; });
    };
    ManageAssetComponent.prototype.getVersion = function () {
        var _this = this;
        this.assetService.getVersion()
            .subscribe(function (version) { return _this.version = version; }, function (error) { return _this.errorMessage = error; });
    };
    ManageAssetComponent.prototype.prepareSaveAsset = function () {
        var formModel = this.assetForm.value;
        // deep copies here if we had nested complex types
        // ...
        // return new `Asset` object containing a combination of original asset value(s)
        // and deep copies of changed form model values
        var saveAsset = new asset_1.Asset(new decktype_1.DeckType(formModel.deckType.Id, formModel.deckType.Value), this.model.Id, formModel.inspectionDate, formModel.inspectionNo, formModel.highwayBridge, formModel.maintenanceReq, this.model.Name, this.model.Owner, formModel.structureNo);
        return saveAsset;
    };
    ManageAssetComponent.prototype.onSubmit = function () {
        this.model = this.prepareSaveAsset();
        this.assetService.saveAsset(this.model).subscribe();
        this.ngOnChanges();
    };
    Object.defineProperty(ManageAssetComponent.prototype, "modeldiagnostic", {
        // TODO: Remove this when we're done
        get: function () { return JSON.stringify(this.model); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ManageAssetComponent.prototype, "dtdiagnostic", {
        get: function () { return JSON.stringify(this.deckTypes); },
        enumerable: true,
        configurable: true
    });
    __decorate([
        core_1.Input(), 
        __metadata('design:type', asset_1.Asset)
    ], ManageAssetComponent.prototype, "model", void 0);
    ManageAssetComponent = __decorate([
        core_1.Component({
            selector: 'manageasset-component',
            template: "\n<!-- Include to see model descriptions at the top of the form\n{{modeldiagnostic}}\n{{dtdiagnostic}}\n    -->\n<div class=\"container\">\n    <h1>{{model?.Name}}</h1>\n    <form [formGroup]=\"assetForm\" (ngSubmit)=\"onSubmit()\">\n\n      <div class=\"form-group\">\n        <label class=\"center-block\">Inspection No:\n          <input class=\"form-control\" formControlName=\"inspectionNo\">            \n        </label>\n      </div>\n\n    <div class=\"form-group\">\n        <label class=\"center-block\">Inspection Date:\n          <input class=\"form-control\" formControlName=\"inspectionDate\" type=\"date\" >\n        </label>\n      </div>\n\n      <div class=\"form-group\">\n        <label class=\"center-block\">Structure No:\n          <input class=\"form-control\" formControlName=\"structureNo\">\n        </label>\n      </div>\n\n      <div class=\"form-group\">\n        <label class=\"center-block\">Deck Type::\n            <select class=\"form-control\" formControlName=\"deckType\">\n                <option *ngFor=\"let dt of deckTypes\" [value]=\"dt\">{{dt.Value}}</option>\n            </select>\n        </label>\n      </div>\n\n      <div class=\"checkbox\">\n        <label class=\"center-block\">\n          <input type=\"checkbox\" formControlName=\"maintenanceReq\">Maintenance Req?\n        </label>\n      </div>\n\n      <div class=\"checkbox\">\n        <label class=\"center-block\">\n          <input type=\"checkbox\" formControlName=\"highwayBridge\">Highway Bridge?\n        </label>\n      </div>\n\n    <div style=\"margin-bottom: 1em\">\n        <button type=\"submit\"\n                [disabled]=\"assetForm.pristine || assetForm.$invalid\" class=\"btn btn-success\">Save</button> &nbsp;\n        <button type=\"reset\" (click)=\"revert()\"\n                [disabled]=\"assetForm.pristine\" class=\"btn btn-danger\">Revert</button>\n        </div>\n\n    </form>\n\n<!-- Include to see form data/state at the bottom of the form\n    <p>Form value: {{ assetForm.value | json }}</p>\n    <p>Form status: {{ assetForm.status | json }}</p>    \n\n\n-->\n\n</div>\n    "
        }), 
        __metadata('design:paramtypes', [asset_service_1.AssetService, forms_1.FormBuilder])
    ], ManageAssetComponent);
    return ManageAssetComponent;
}());
exports.ManageAssetComponent = ManageAssetComponent;
