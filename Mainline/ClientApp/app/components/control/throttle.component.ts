import { Component, Input, Output, EventEmitter, ViewChild, ElementRef, OnInit } from '@angular/core';
import { ISpeedAndDirection } from "./../elements/throttle";
declare var $: any;

@Component({
    selector: 'throttle',
    templateUrl: './throttle.component.html',
    styleUrls: ['./throttle.component.css']
})
export class ThrottleComponent implements OnInit {
    @Input() throttle: ISpeedAndDirection;
    @Output() onThrottleChange: EventEmitter<ISpeedAndDirection> = new EventEmitter();
    @ViewChild('throttle') throttleElement: ElementRef;

    topOffset = 40;

    ngOnInit() {
        this.setInitPosition();

        $(this.throttleElement.nativeElement).draggable({
            axis: 'y',
            containment: 'parent',
            scroll: false,
            drag: this.onDrag.bind(this)
        });
    }

    setSpeed(speed: number) {
        this.throttle.speed = speed;
        this.onThrottleChange.emit(this.throttle);
    }

    onDrag() {
        var throttle = $(this.throttleElement.nativeElement);
        var childPos = throttle.position();
        var parentHeight = throttle.parent().height();

        this.setSpeed(this.calculatePercentage(childPos.top, parentHeight - this.topOffset));
    }

    reposition(event: any) {
        var throttle = $(this.throttleElement.nativeElement);
        var parentHeight = throttle.parent().height();

        var y = (event.pageY - throttle.parent().offset().top);
        if (y > parentHeight - this.topOffset) {
            y = parentHeight - this.topOffset;
        }
        if (y < 0) {
            y = 0;
        }

        $(this.throttleElement.nativeElement).animate({ top: y });
        this.setSpeed(this.calculatePercentage(y, parentHeight - this.topOffset));
    }

    setInitPosition() {
        var throttle = $(this.throttleElement.nativeElement);
        var parentHeight = throttle.parent().height() - this.topOffset;
        var y = (parentHeight / 100) * (100 - this.throttle.speed);
        $(this.throttleElement.nativeElement).animate({ top: y });
    }

    calculatePercentage(elementPos: number, max: number) {
        return Math.ceil(((max - elementPos) / max) * 100);
    }
}