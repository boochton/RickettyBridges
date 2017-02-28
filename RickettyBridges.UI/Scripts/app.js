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
var asset_service_1 = require('./asset-service');
var AppComponent = (function () {
    function AppComponent(assetService) {
        this.assetService = assetService;
        this.isLoading = false;
        // Hard coded for demo purposes...
        this.assets = ['Inspection Report 1.1', 'Bridge Report 2.2'];
    }
    AppComponent.prototype.getAsset = function (id) {
        var _this = this;
        switch (id) {
            case 'Inspection Report 1.1':
                this.assetService.getAsset(1)
                    .subscribe(function (model) { return _this.model = model; }, function (error) { return _this.errorMessage = error; });
                break;
            default:
                this.assetService.getAsset(3)
                    .subscribe(function (model) { return _this.model = model; }, function (error) { return _this.errorMessage = error; });
                break;
        }
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'rickettybridges-app',
            template: "    \n    <nav class=\"navbar navbar-inverse sidebar\">\n        <div class=\"container-fluid\">\n        <div class=\"collapse navbar-collapse\" id=\"bs-sidebar-navbar-collapse-1\">\n            <ul class=\"nav navbar-nav\">\n                <li class=\"active\"><a href=\"#\">Dashboard<span style=\"font-size:16px;\" class=\"pull-right hidden-xs showopacity glyphicon glyphicon-home\"></span></a></li>\n                <li class=\"dropdown\">\n                    <a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">Reports <span class=\"caret\"></span><span style=\"font-size:16px;\" class=\"pull-right hidden-xs showopacity glyphicon glyphicon-folder-open\"></span></a>\n                    \n                    <ul class=\"dropdown-menu forAnimate\" role=\"menu\" *ngFor=\"let x of assets\">\n                      <li>\n                        <a (click)=\"getAsset(x)\" href=\"#\">{{x}}</a>\n                      </li>\n                    </ul>\n\n                    <!--<ul class=\"dropdown-menu forAnimate\" role=\"menu\">\n                        <li><a (click)=\"getAsset(1)\" href=\"#\">Inspection Report 1.1</a></li>\n                        <li (click)=\"getAsset(3)\"><a href=\"#\">Bridge Report 2.2</a></li>\n                    </ul>-->\n                </li>                        \n                <li><a href=\"#\">Network<span style=\"font-size:16px;\" class=\"pull-right hidden-xs showopacity glyphicon glyphicon-user\"></span></a></li>\n                <li><a href=\"#\">Settings<span style=\"font-size:16px;\" class=\"pull-right hidden-xs showopacity glyphicon glyphicon-cog\"></span></a></li>                        \n            </ul>\n        </div>\n    </div>\n    </nav>\n    <div class=\"main\">\n        <div *ngIf=\"model\">\n            <manageasset-component [model]=model>\n                <div class=\"jumbotron\">\n                    Loading Asset Manager...\n                </div>\n            </manageasset-component>\n        </div>\n    </div>\n  "
        }), 
        __metadata('design:paramtypes', [asset_service_1.AssetService])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
