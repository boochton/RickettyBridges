import { DeckType } from './decktype';

export class Asset {
     constructor(
         public DeckType: DeckType,
         public Id: number,         
         public InspectionDate: string,
         public InspectionNumber: string,
         public IsHighwayBridge: boolean,
         public IsMaintenanceRequired: boolean,
         public Name: string,
         public Owner: string,
         public StructureNumber: string
     ) {         
     }        
 }