import { Component, Input, OnInit } from '@angular/core';
import { ThrottleService } from './../services/throttle.service';
import { ITrain } from "./../elements/train";
import { IThrottle } from "./../elements/throttle";

@Component({
    selector: 'trainControl',
    templateUrl: './trainControl.component.html',
    styleUrls: ['./trainControl.component.css']
})
export class TrainControlComponent implements OnInit {
    @Input() train: ITrain;
    throttle: IThrottle;

    constructor(private throttleService: ThrottleService) {
    }

    ngOnInit() {
        this.throttle = this.throttleService.getThrottle(this.train);
    }

    onThrottleChange(throttle: IThrottle) {
        this.throttleService.setThrottle(throttle);
    }

    setDirection(direction: number) {
        this.throttle.direction = direction;
        this.throttleService.setThrottle(this.throttle);
    }
}