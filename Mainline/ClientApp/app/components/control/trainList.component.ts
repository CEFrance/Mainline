import { Component, Inject } from '@angular/core';
import { TrainService } from './../services/train.service';
import { ITrain } from "./../elements/train";

@Component({
    selector: 'trainList',
    templateUrl: './trainList.component.html'
})
export class TrainListComponent {
    constructor(private trainService: TrainService) {
    }
}