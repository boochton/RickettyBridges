// Observable Version
import { Injectable }              from '@angular/core';
import { Http, Response }          from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { Asset } from './asset';
import { DeckType } from './decktype';

@Injectable()
export class AssetService {
    private getAssetUrl = 'http://rickettybridges.api.tomewinconsultancy.com.au/api/Asset/';  // URL to web API
    private getDeckTypesUrl = 'http://rickettybridges.api.tomewinconsultancy.com.au/api/GetDeckTypes';  // URL to web API
    private getVersionUrl = 'http://rickettybridges.api.tomewinconsultancy.com.au/api/version';  // URL to web API
    private saveAssetUrl = 'http://rickettybridges.api.tomewinconsultancy.com.au/api/Asset';  // URL to web API


    constructor(private http: Http) { }

    getAsset(id: number): Observable<Asset> {
        return this.http.get(this.getAssetUrl + id)
            .map(this.extractData)
            .catch(this.handleError);
    }

    getDeckTypes(): Observable<DeckType[]> {
        return this.http.get(this.getDeckTypesUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }

    getVersion(): Observable<string> {
        return this.http.get(this.getVersionUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }

    saveAsset(asset: Asset): Observable<Asset> {
        let body = JSON.stringify(asset);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.saveAssetUrl, body, options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        if (body.data)
            return body.data || {};
        else
            return body || {};
    }

    private handleError(error: Response | any) {
        // In a real world app, we might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }

    //private logError(http: Http, error: string) {
    //    var request = { errorData: JSON.stringify(error) };
    //    let headers = new Headers({ 'Content-Type': 'application/json' });
    //    let options = new RequestOptions({ headers: headers });
    //    console.log("logging error to api: " + error);
    //    console.log(http);
    //    console.log(request);
    //    console.log(headers);
    //    console.log(options);
    //    console.log(tis.logErrorUrl);
    //    http.post(this.logErrorUrl, request, options);
    //}
}