from django.db import models
from django.contrib.auth.models import User
from django.utils.translation import gettext_lazy as _

class Tastes(models.TextChoices):
    DIDNT_LIKE = "DL", _("Didn't Like")
    TASTY = "TS", _("Tasty")
    VERY_TASTY = "VT", _("Very Tasty")
    EXCEPTIONAL = "EX", _("Exceptional")

class Presentations(models.TextChoices):
    DIDNT_LIKE = "DL", _("Didn't Like")
    WELL_PRESENTED = "WP", _("Well Presented")
    VERY_WELL = "VW", _("Very Well")
    EXCEPTIONAL = "EX", _("Exceptional")

class Originalities(models.TextChoices):
    DIDNT_LIKE = "DL", _("Didn't Like")
    ORIGINAL = "OR", _("Original")
    VERY_ORIGINAL = "VO", _("Very Original")
    EXCEPTIONAL = "EX", _("Exceptional")

class Contest(models.Model):
    contest_date = models.DateField("Contest Date")

    def __unicode__(self):
        return f"Contest on {self.contest_date}"
    
    def __str__(self):
        return f"Contest on {self.contest_date}"

class Pintxo(models.Model):
    name = models.CharField(max_length=100)
    description = models.TextField(max_length=2048, blank=True, null=True)
    owner = models.ForeignKey(User, on_delete=models.CASCADE)
    contest = models.ForeignKey(Contest, on_delete=models.CASCADE)

    def __unicode__(self):
        return f"{self.name} by {self.owner.get_full_name()}"
    
    def __str__(self):
        return f"{self.name} by {self.owner.get_full_name()}"

class Vote(models.Model):
    taste_vote = models.CharField(max_length=2, choices=Tastes.choices)
    presentation_vote = models.CharField(max_length=2, choices=Presentations.choices)
    originality_vote = models.CharField(max_length=2, choices=Originalities.choices)
    pintxo = models.ForeignKey(Pintxo, on_delete=models.CASCADE)
    voter = models.ForeignKey(User, on_delete=models.CASCADE)

    def __unicode__(self):
        return f"{self.voter.get_full_name()} voted {self.taste_vote} - {self.presentation_vote} - {self.originality_vote}"
    
    def __str__(self):
        return f"{self.voter.get_full_name()} voted {self.taste_vote} - {self.presentation_vote} - {self.originality_vote}"