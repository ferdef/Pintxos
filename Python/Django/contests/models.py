from django.db import models

# Create your models here.

class Contest(models.Model):
    contest_date = models.DateField()
    active = models.BooleanField(default=True)

    def save(self, *args, **kwargs):
        if self.active == True:
            [contest.set_inactive() for contest in Contest.objects.all()]
            self.active = True
        super(Contest, self).save(*args, **kwargs)

    def set_inactive(self):
        self.active = False
        self.save()

    def __str__(self):
        str_date = self.contest_date.strftime("%d-%b-%Y")
        return str_date