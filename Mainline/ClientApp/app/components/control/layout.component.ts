import { Component } from '@angular/core';
import { ITrackPiece, IPosition } from "./../elements/track";

@Component({
    selector: 'layout',
    templateUrl: './layout.component.html',
    styleUrls: ['./layout.component.css']
})

export class LayoutComponent {
    public trackPieces: ITrackPiece[];

    constructor() {
        this.trackPieces = [
        {
            id: 1,
            type: 'straight'
        },
        {
            id: 2,
            type: 'straight',
            inputId: 1
        },
        {
            id: 3,
            type: 'straight',
            inputId: 2
        },
        {
            id: 4,
            type: 'straight',
            inputId: 3
        },
        {
            id: 5,
            type: 'straight',
            inputId: 4
        }];
    }

    getPosition(trackPiece: ITrackPiece): IPosition {
        return { x: trackPiece.id * 40, y: 0 };
    }
}

