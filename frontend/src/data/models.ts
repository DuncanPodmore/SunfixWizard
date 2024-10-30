export interface Client {
    clientId: number;
    name: string;
    contactEmail: string;
    phone: string;
    projects?: Project[]; // Optional relationship
}

export interface Project {
    projectId: number;
    name: string;
    clientId: number;
    client?: Client; // Optional relationship
    quotes?: Quote[]; // Optional relationship
}

export interface Quote {
    quoteId: number;
    projectId: number;
    project?: Project; // Optional relationship
    totalCost: number;
    partsSnapshot: PartSnapshot[]; // Immutable part list as JSON
    createdAt: Date;
    active: boolean; // For soft delete
}

export interface PartSnapshot {
    partId: number;
    name: string;
    quantity: number;
    price: number;
}
export interface Part {
    partId: number;
    name: string;
    type: string; // E.g., 'Bolt', 'Rail'
    price: number;
}
export interface PartPreset {
    presetId: number;
    name: string;
    roofSheet: string; // Associated roof type
    parts: PartPresetItem[]; // List of parts with quantity
}

export interface PartPresetItem {
    id: number;
    partId: number;
    part?: Part; // Optional relationship
    quantity: number;
}
export interface RoofType {
    roofTypeId: number;
    name: string; // E.g., 'Trapezoidal', 'Flat'
    roofSheets?: RoofSheet[]; // Optional relationship
}
export interface RoofSheet {
    roofSheetId: number;
    name: string; // E.g., 'Corrugated Sheet'
    roofTypeId: number;
    roofType?: RoofType; // Optional relationship
}
