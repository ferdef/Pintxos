from django.db import models

class Contest(models.Model):
    contest_date = models.DateField("Contest Date")
    active = models.BooleanField("Active?", default=False)

    def __unicode__(self):
        return f"Contest on {self.contest_date}"
    
    def __str__(self):
        return f"Contest on {self.contest_date}"

    def set_active(self):
        contests = Contest.objects.all()
        for contest in contests:
            contest.active = False
        self.active = True