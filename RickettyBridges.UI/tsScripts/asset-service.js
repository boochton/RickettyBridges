"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
// Observable Version
var core_1 = require('@angular/core');
var http_1 = require('@angular/http');
var http_2 = require('@angular/http');
var Rx_1 = require('rxjs/Rx');
require('rxjs/add/operator/catch');
require('rxjs/add/operator/map');
var AssetService = (function () {
    function AssetService(http) {
        this.http = http;
        this.getAssetUrl = 'http://rickettybridges.api.tomewinconsultancy.com.au/api/Asset/'; // URL to web API
        this.getDeckTypesUrl = 'http://rickettybridges.api.tomewinconsultancy.com.au/api/GetDeckTypes'; // URL to web API
        this.getVersionUrl = 'http://rickettybridges.api.tomewinconsultancy.com.au/api/version'; // URL to web API
        this.saveAssetUrl = 'http://rickettybridges.api.tomewinconsultancy.com.au/api/Asset'; // URL to web API
    }
    AssetService.prototype.getAsset = function (id) {
        return this.http.get(this.getAssetUrl + id)
            .map(this.extractData)
            .catch(this.handleError);
    };
    AssetService.prototype.getDeckTypes = function () {
        return this.http.get(this.getDeckTypesUrl)
            .map(this.extractData)
            .catch(this.handleError);
    };
    AssetService.prototype.getVersion = function () {
        return this.http.get(this.getVersionUrl)
            .map(this.extractData)
            .catch(this.handleError);
    };
    AssetService.prototype.saveAsset = function (asset) {
        var body = JSON.stringify(asset);
        var headers = new http_2.Headers({ 'Content-Type': 'application/json' });
        var options = new http_2.RequestOptions({ headers: headers });
        return this.http.post(this.saveAssetUrl, body, options)
            .map(this.extractData)
            .catch(this.handleError);
    };
    AssetService.prototype.extractData = function (res) {
        var body = res.json();
        if (body.data)
            return body.data || {};
        else
            return body || {};
    };
    AssetService.prototype.handleError = function (error) {
        // In a real world app, we might use a remote logging infrastructure
        var errMsg;
        if (error instanceof http_1.Response) {
            var body = error.json() || '';
            var err = body.error || JSON.stringify(body);
            errMsg = error.status + " - " + (error.statusText || '') + " " + err;
        }
        else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Rx_1.Observable.throw(errMsg);
    };
    AssetService = __decorate([
        core_1.Injectable()
    ], AssetService);
    return AssetService;
}());
exports.AssetService = AssetService;
//# sourceMappingURL=asset-service.js.map