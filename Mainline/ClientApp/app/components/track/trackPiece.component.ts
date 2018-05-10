import { Component, Input } from '@angular/core';
import { ITrackPiece, IPosition } from "./../elements/track";

@Component({
    selector: 'trackPiece',
    templateUrl: './trackPiece.component.html',
    styleUrls: ['./trackPiece.component.css']
})
export class TrackPieceComponent {
    @Input() trackPiece: ITrackPiece;
    @Input() position: IPosition;
}