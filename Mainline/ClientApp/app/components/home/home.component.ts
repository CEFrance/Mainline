import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    public trainLinkStatus: TrainLinkStatus[];

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        http.get(baseUrl + 'api/TrainLink/Status').subscribe(result => {
            this.trainLinkStatus = result.json() as TrainLinkStatus[];
        }, error => console.error(error));
    }

    connect() {
        this.http.get(this.baseUrl + 'api/TrainLink/Connect').subscribe(result => {
            this.trainLinkStatus = result.json() as TrainLinkStatus[];
        }, error => console.error(error));
    }
}

interface TrainLinkStatus {
    connected: boolean;
}
