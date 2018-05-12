import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { ISpeedAndDirection } from "./../elements/throttle";

@Injectable()
export class ThrottleService {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    private throttle: ISpeedAndDirection;

    setThrottle(throttle: ISpeedAndDirection) {
        this.http.post(this.baseUrl + 'api/Train/setspeedanddirection', throttle).subscribe(result => {
        }, error => console.error(error));
    }

    getThrottle(eAddress: number): ISpeedAndDirection {

        if (this.throttle == null) {
            this.http.get(this.baseUrl + 'api/Train/getspeedanddirection', { params: { eAddress: eAddress } }).subscribe(result => {
                this.throttle = result.json() as ISpeedAndDirection;
            }, error => console.error(error));
        }

        return this.throttle;
    }
}