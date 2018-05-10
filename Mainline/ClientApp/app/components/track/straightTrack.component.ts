import { Component, Input } from '@angular/core';
import { IPosition } from "./../elements/track";

@Component({
    selector: 'straightTrack',
    templateUrl: './straightTrack.component.html',
    styleUrls: ['./straightTrack.component.css']
})
export class StraightTrackComponent {
    @Input() position: IPosition;
}