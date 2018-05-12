import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { ISpeedAndDirection } from "./../elements/throttle";

@Injectable()
export class ThrottleService {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    private throttles: ISpeedAndDirection[] = [];

    setThrottle(throttle: ISpeedAndDirection) {
        this.http.post(this.baseUrl + 'api/Train/setspeedanddirection', throttle).subscribe(result => {
        }, error => console.error(error));
    }

    getThrottle(eAddress: number): ISpeedAndDirection {
        console.log(eAddress);
        var throttle = this.throttles.find(o => o.eAddress === eAddress);
        if (throttle == null) {
            this.http.get(this.baseUrl + 'api/Train/getspeedanddirection', { params: { eAddress: eAddress } }).subscribe(result => {
                throttle = result.json() as ISpeedAndDirection;
                this.throttles.push(throttle);
            }, error => console.error(error));
        }

        return throttle as any;
    }
}