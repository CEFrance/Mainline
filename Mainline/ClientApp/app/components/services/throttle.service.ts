import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { ITrain } from "./../elements/train";
import { IThrottle } from "./../elements/throttle";

@Injectable()
export class ThrottleService {
    throttle: IThrottle = {
        eAddress: 1,
        speed: 0,
        direction: 1
    };

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    setThrottle(throttle: IThrottle) {
        this.http.post(this.baseUrl + 'api/Train/setspeedanddirection', throttle).subscribe(result => {
        }, error => console.error(error));
    }

    getThrottle(train: ITrain): IThrottle {
        return {
            eAddress: train.functions.eAddress,
            speed: 0,
            direction: 1
        };
    }
}