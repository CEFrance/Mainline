import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    public trainLinkStatus: ConnectionLinkStatus[];
    public arduinoLinkStatus: ConnectionLinkStatus[];

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        http.get(baseUrl + 'api/trainlink/status').subscribe(result => {
            this.trainLinkStatus = result.json() as ConnectionLinkStatus[];
        }, error => console.error(error));

        http.get(baseUrl + 'api/arduinolink/status').subscribe(result => {
            this.arduinoLinkStatus = result.json() as ConnectionLinkStatus[];
        }, error => console.error(error));
    }

    connectTrainLink() {
        this.http.get(this.baseUrl + 'api/trainlink/connect').subscribe(result => {
            this.arduinoLinkStatus = result.json() as ConnectionLinkStatus[];
        }, error => console.error(error));
    }

    connectArduinoLink() {
        this.http.get(this.baseUrl + 'api/arduinolink/connect').subscribe(result => {
            this.arduinoLinkStatus = result.json() as ConnectionLinkStatus[];
        }, error => console.error(error));
    }
}

interface ConnectionLinkStatus {
    connected: boolean;
}
