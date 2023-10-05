from django.db import models

class Contest(models.Model):
    contest_date = models.DateField("Contest Date")

    def __unicode__(self):
        return f"Contest on {self.contest_date}"
    
    def __str__(self):
        return f"Contest on {self.contest_date}"

    def clean_contest(self):
        pass