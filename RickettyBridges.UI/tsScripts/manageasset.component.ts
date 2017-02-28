import { Component, Input, OnInit, OnChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs/Observable';

import { Asset } from './asset';
import { DeckType } from './decktype';
import { AssetService } from './asset-service';


@Component({
    selector: 'manageasset-component',
    template: `
<!-- Include to see model descriptions at the top of the form
{{modeldiagnostic}}
{{dtdiagnostic}}
    -->
<div class="container">
    <h1>{{model?.Name}}</h1>
    <form [formGroup]="assetForm" (ngSubmit)="onSubmit()">

      <div class="form-group">
        <label class="center-block">Inspection No:
          <input class="form-control" formControlName="inspectionNo">            
        </label>
      </div>

    <div class="form-group">
        <label class="center-block">Inspection Date:
          <input class="form-control" formControlName="inspectionDate" type="date" >
        </label>
      </div>

      <div class="form-group">
        <label class="center-block">Structure No:
          <input class="form-control" formControlName="structureNo">
        </label>
      </div>

      <div class="form-group">
        <label class="center-block">Deck Type::
            <select class="form-control" formControlName="deckType">
                <option *ngFor="let dt of deckTypes" [value]="dt">{{dt.Value}}</option>
            </select>
        </label>
      </div>

      <div class="checkbox">
        <label class="center-block">
          <input type="checkbox" formControlName="maintenanceReq">Maintenance Req?
        </label>
      </div>

      <div class="checkbox">
        <label class="center-block">
          <input type="checkbox" formControlName="highwayBridge">Highway Bridge?
        </label>
      </div>

    <div style="margin-bottom: 1em">
        <button type="submit"
                [disabled]="assetForm.pristine || assetForm.$invalid" class="btn btn-success">Save</button> &nbsp;
        <button type="reset" (click)="revert()"
                [disabled]="assetForm.pristine" class="btn btn-danger">Revert</button>
        </div>

    </form>

<!-- Include to see form data/state at the bottom of the form
    <p>Form value: {{ assetForm.value | json }}</p>
    <p>Form status: {{ assetForm.status | json }}</p>    
-->

</div>
    `
})

export class ManageAssetComponent implements OnChanges{
    @Input() model: Asset;

    assetForm: FormGroup;
    errorMessage: string;    
    deckTypes: DeckType[];
    formattedInspectionDate = '';
    version: string;
    mode: 'Observable';
    
    constructor(private assetService: AssetService, private fb: FormBuilder) {
        this.createForm();
    }

    createForm() {
        this.assetForm = this.fb.group({
            inspectionNo: ['', Validators.required],
            inspectionDate: ['', Validators.required],
            structureNo: '',
            deckType: '',
            maintenanceReq: '',
            highwayBridge: ''
        });
    }

    ngOnInit() {
        this.getVersion();
        //this.getAsset();
        this.getDeckTypes();        
    }

    revert() { this.ngOnChanges(); }

    ngOnChanges() {
            this.assetForm.reset({
                inspectionNo: this.model.InspectionNumber,
                inspectionDate: this.model.InspectionDate,
                structureNo: this.model.StructureNumber,
                deckType: this.model.DeckType,
                //deckType: new DeckType(this.model.DeckType.Id, this.model.DeckType.Value)
                maintenanceReq: this.model.IsMaintenanceRequired,
                highwayBridge: this.model.IsHighwayBridge
            });
    }

    getAsset(id: number) {
        this.assetService.getAsset(id)
            .subscribe(model => this.model = model,
            error => this.errorMessage = <any>error);
    }

    getDeckTypes() {
        this.assetService.getDeckTypes()
            .subscribe(deckTypes => this.deckTypes = deckTypes,
            error => this.errorMessage = <any>error);
    }

    getVersion() {
        this.assetService.getVersion()
            .subscribe(version => this.version = version,
            error => this.errorMessage = <any>error);
    }

    prepareSaveAsset(): Asset {
        const formModel = this.assetForm.value;

        // deep copies here if we had nested complex types
        // ...

        // return new `Asset` object containing a combination of original asset value(s)
        // and deep copies of changed form model values
        const saveAsset = new Asset(new DeckType(formModel.deckType.Id, formModel.deckType.Value),
                               this.model.Id,
                               formModel.inspectionDate,
                               formModel.inspectionNo,
                               formModel.highwayBridge,
                               formModel.maintenanceReq,
                               this.model.Name,
                               this.model.Owner,
                               formModel.structureNo);
        return saveAsset;
    }

    onSubmit() {
        this.model = this.prepareSaveAsset();
        this.assetService.saveAsset(this.model).subscribe();
        this.ngOnChanges();
    }

    // TODO: Remove this when we're done
    get modeldiagnostic() { return JSON.stringify(this.model); }
    get dtdiagnostic() { return JSON.stringify(this.deckTypes); }
}