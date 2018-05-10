export interface ITrackPiece {
    id: number;
    type: string;
    inputId?: number;
    outputId?: number;
}

export interface IPosition {
    x: number;
    y: number;
}