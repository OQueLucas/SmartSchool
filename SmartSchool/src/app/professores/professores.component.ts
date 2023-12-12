import { Component, OnInit, TemplateRef } from '@angular/core';
import { Professor } from '../models/Professor';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ProfessorsService } from './professor.service';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.css'],
})
export class ProfessoresComponent implements OnInit {
  public ProfessorForm: FormGroup;
  titulo = 'Professores';
  public professorSelecionado!: Professor;
  modalRef?: BsModalRef;
  public professores: Professor[];

  professorSelect(professor: Professor) {
    this.professorSelecionado = professor;
    this.ProfessorForm.patchValue(professor);
  }

  constructor(
    private fb: FormBuilder,
    private modalService: BsModalService,
    private professorService: ProfessorsService
  ) {
    this.criarForm();
  }

  openModal(template: TemplateRef<void>) {
    this.modalRef = this.modalService.show(template);
  }
  ngOnInit(): void {
    this.carregarProfessor();
  }

  carregarProfessor() {
    this.professorService.getAll().subscribe({
      next: (professores: Professor[]) => {
        this.professores = professores;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  criarForm() {
    this.ProfessorForm = this.fb.group({
      id: ['', Validators.required],
      nome: ['', Validators.required],
    });
  }

  salvarProfessor(professor: Professor) {
    this.professorService.put(professor.id, professor).subscribe({
      next: (retorno: Professor) => {
        console.log(retorno);
        this.carregarProfessor();
      },
      error: (error: any) => {
        console.log(error);
      },
    });
  }

  professorSubmit() {
    this.salvarProfessor(this.ProfessorForm.value);
  }

  voltar() {
    this.professorSelecionado = null;
  }
}
