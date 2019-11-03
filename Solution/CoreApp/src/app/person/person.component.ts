import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { PersonService } from '../services/person.service';
import { Person } from '../models/person';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.scss']
})
export class PersonComponent implements OnInit {
  persons$: Observable<Person[]>;
  persons: Person[];

  form: FormGroup;
  errorMessage: any;
  firstName: string;
  lastName: string;

  constructor(private personService: PersonService
    , private formBuilder: FormBuilder, private avRoute: ActivatedRoute
    , private router: Router) {
  }

  ngOnInit() {
    this.getPersons();
    this.firstName = 'firstName'; 
    this.lastName = 'lastName';
    this.form = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]]
    });
  }

  getPersons() {
    this.persons$ = this.personService.getPersons();
    this.persons$.subscribe(res => {
      this.persons = res
    });
    console.log(this.persons$)
  }

  save() {
    if(!this.form.valid) {
      return;
    }

    let person: Person = {
      firstName: this.form.get(this.firstName).value,
      lastName: this.form.get(this.lastName).value
    }

    this.personService.savePerson(person)
    .subscribe((data) => {
      console.log(data);
      //Fetch results after saved
      this.getPersons();
    });
  }
}
