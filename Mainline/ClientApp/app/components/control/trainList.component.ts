import { Component } from '@angular/core';
import { TrainService } from './../services/train.service';

@Component({
    selector: 'trainList',
    templateUrl: './trainList.component.html'
})
export class TrainListComponent {
    constructor(private trainService: TrainService) {
    }
}