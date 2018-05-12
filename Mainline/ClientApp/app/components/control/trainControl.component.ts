import { Component, Input, OnInit } from '@angular/core';
import { ThrottleService } from './../services/throttle.service';
import { ITrain } from "./../elements/train";
import { ISpeedAndDirection } from "./../elements/throttle";

@Component({
    selector: 'trainControl',
    templateUrl: './trainControl.component.html',
    styleUrls: ['./trainControl.component.css']
})
export class TrainControlComponent implements OnInit {
    @Input() train: ITrain;
    throttle: ISpeedAndDirection;

    constructor(private throttleService: ThrottleService) {
    }

    ngOnInit() {
        this.throttle = this.throttleService.getThrottle(this.train.functions.eAddress);
    }

    onThrottleChange(throttle: ISpeedAndDirection) {
        this.throttleService.setThrottle(throttle);
    }

    setDirection(direction: number) {
        this.throttle.direction = direction;
        this.throttleService.setThrottle(this.throttle);
    }
}