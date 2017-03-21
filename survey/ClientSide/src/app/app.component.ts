import { Component } from '@angular/core';
import { Http, Headers } from '@angular/http';
import 'rxjs/Rx';

@Component({
  selector: 'my-app',
  template: `<h1>Hello {{name}}</h1>`,
})
export class AppComponent {
    name = 'Angular';

    constructor(private http: Http) {
        
    }

    ngOnInit() {
        let headers = new Headers();
        //headers.append('Access-Control-Allow-Origin', '*');
        headers.append('Accept', 'application/json');
        headers.append('Content-Type', 'application/json');

        this.http.get('http://localhost:51193/api/survey', headers).map(response => {
            let json = response.json();
            return json[0];
        }).subscribe(x => {
            this.name = x.title;
        });;
    }
}
