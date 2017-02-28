export interface Asset {
        id: string;
        deckTypeId: number;
        deckTypeValue: string;
        name: string;
        inspectionNumber: string;
        inspectionDate: Date;
        structureNumber: string;
        isMaintenanceRequired: boolean;
        isHighwayBridge: boolean;
        owner: string;
}   