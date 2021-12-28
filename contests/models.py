from django.db import models

# Create your models here.

class Contest(models.Model):
    contest_date = models.DateField()

    def __str__(self):
        return  self.contest_date.strftime("%d-%b-%Y")