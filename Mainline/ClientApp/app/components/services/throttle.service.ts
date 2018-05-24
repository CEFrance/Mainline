import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { ISpeedAndDirection } from "./../elements/throttle";

@Injectable()
export class ThrottleService {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        this.loading = true;

        this.http.get(this.baseUrl + 'api/Train/getspeedanddirection', { params: { } }).subscribe(result => {
            this.throttles = result.json() as ISpeedAndDirection[];
            this.loading = false;
        }, error => console.error(error));
    }

    private loading: boolean;
    private throttles: ISpeedAndDirection[] = [];

    isLoading() {
        return this.loading;
    }

    setThrottle(throttle: ISpeedAndDirection) {
        this.http.post(this.baseUrl + 'api/Train/setspeedanddirection', throttle).subscribe(result => {
        }, error => console.error(error));
    }

    getThrottle(eAddress: number): ISpeedAndDirection {
        var throttle = this.throttles.find(o => o.eAddress === eAddress);
        if (throttle == null) {
            throw "No state";
        }

        return throttle;
    }
}