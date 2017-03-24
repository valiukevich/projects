import { Component } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import 'rxjs/Rx';

@Component({
  selector: 'my-app',
  templateUrl: './app/app.component.html',
})
export class AppComponent {
    model: any;
    survey: any;

    constructor(private http: Http) {
        
    }

    ngOnInit() {
        this.load();
    }

    load() {
        this.http.get('http://localhost:51193/api/survey').map(response => {
            let json = response.json();
            return json[0];
        }).subscribe(x => {
            this.survey = x.survey;
            this.model = x;
        });;
    }

    save() {
        console.log(this.model);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        this.http.post('http://localhost:51193/api/survey', JSON.stringify(this.model), options).catch(this.handleError).subscribe(x => {
            console.log(x);
            this.load();
        });
    }

    selectAnswer(question: any, answer: any) {
        if (!this.model.answers) {
            this.model.answers = Array<any>();
        }

        let userAnswer = this.model.answers.find((x: any) => x.question.text == question.text);
        if (!userAnswer) {
            this.model.answers.push({
                question: question,
                answers: []
            });
            userAnswer = this.model.answers.find((x: any) => x.question.text == question.text);
        }

        if (question.questionType === 0) {//radio
            userAnswer.answers = [{ answer: answer }];
        }
        else if (question.questionType === 1) { //check boxes
            //answer.answers = [{ answer: answer }];
            let item = userAnswer.answers.find((x: any) => x.answer == answer);
            if (item) {
                var index = userAnswer.answers.indexOf(item, 0);
                if (index > -1) {
                    userAnswer.answers.splice(index, 1);
                }
                //delete userAnswer.answers[item];
            } else {
                userAnswer.answers.push({ answer: answer });
            }
        }
    }

    selected(question: any, answer: any) : boolean {
        let userAnswer = this.model.answers.find((x: any) => x.question.text == question.text);
        if (!userAnswer) {
            return false;
        }
        let item = userAnswer.answers.find((x: any) => x.answer == answer);
        if (!item) {
            return false;
        }
        return true
    }



    private handleError(error: Response | any) {
        // In a real world app, we might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Promise.reject(errMsg);
    }
}
