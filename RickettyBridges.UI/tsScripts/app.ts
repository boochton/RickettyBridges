import { Component } from '@angular/core';

import { Asset } from './asset';
import { DeckType } from './decktype';
import { AssetService } from './asset-service';

@Component({
    selector: 'rickettybridges-app',
    template: `    
    <nav class="navbar navbar-inverse sidebar">
        <div class="container-fluid">
        <div class="collapse navbar-collapse" id="bs-sidebar-navbar-collapse-1">
            <ul class="nav navbar-nav">
                <li class="active"><a href="#">Dashboard<span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-home"></span></a></li>
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Reports <span class="caret"></span><span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-folder-open"></span></a>
                    
                    <ul class="dropdown-menu forAnimate" role="menu" *ngFor="let x of assets">
                      <li>
                        <a (click)="getAsset(x)" href="#">{{x}}</a>
                      </li>
                    </ul>

                    <!--<ul class="dropdown-menu forAnimate" role="menu">
                        <li><a (click)="getAsset(1)" href="#">Inspection Report 1.1</a></li>
                        <li (click)="getAsset(3)"><a href="#">Bridge Report 2.2</a></li>
                    </ul>-->
                </li>                        
                <li><a href="#">Network<span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-user"></span></a></li>
                <li><a href="#">Settings<span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-cog"></span></a></li>                        
            </ul>
        </div>
    </div>
    </nav>
    <div class="main">
        <div *ngIf="model">
            <manageasset-component [model]=model>
                <div class="jumbotron">
                    Loading Asset Manager...
                </div>
            </manageasset-component>
        </div>
    </div>
  `
})
export class AppComponent {
    errorMessage: string;
    //model = new Asset(new DeckType('0', ''), 0, '', '', false, false, '', '', '');
    model: Asset;
    isLoading = false;
    mode: 'Observable';

    constructor(private assetService: AssetService) {
    }

    // Hard coded for demo purposes...

    public assets: any[] = ['Inspection Report 1.1', 'Bridge Report 2.2']

    getAsset(id: string) {
        switch (id) {
            case 'Inspection Report 1.1':
                this.assetService.getAsset(1)
                    .subscribe(model => this.model = model,
                    error => this.errorMessage = <any>error);
                break;
            default:
                this.assetService.getAsset(3)
                    .subscribe(model => this.model = model,
                    error => this.errorMessage = <any>error);
                break;
        }

    }    
    
}