import { Inject, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { ITrain } from "./../elements/train";

@Injectable()
export class TrainService {
    private loading: boolean;
    public trains: ITrain[];
    private roles = ['Mixed', 'Passenger', 'Freight'];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.loading = true;
        http.get(baseUrl + 'api/Train/TrainList').subscribe(result => {
            this.trains = result.json() as ITrain[];
            this.loading = false;
        }, error => console.error(error));
    }

    getTrains(): ITrain[] {
        return this.trains;
    }

    isLoading(): boolean {
        return this.loading;
    }

    getRole(train: ITrain): string {
        return this.roles[train.role];
    }
}