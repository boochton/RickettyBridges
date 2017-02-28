///<reference path="./../typings/globals/core-js/index.d.ts"/>
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';

import { AppComponent } from './app';
import { ManageAssetComponent } from './manageasset.component';
import { requestOptionsProvider }   from './default-request-options-service';
import { AssetService } from './asset-service';

@NgModule({
    imports: [BrowserModule, FormsModule, ReactiveFormsModule, HttpModule, JsonpModule],
    declarations: [AppComponent, ManageAssetComponent],
    providers: [requestOptionsProvider, AssetService],
    bootstrap: [AppComponent]
})
export class AppModule { }