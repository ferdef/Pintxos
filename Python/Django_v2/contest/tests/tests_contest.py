from django.test import TestCase
from contest.models import Contest

# Create your tests here.
class ContestTestCase(TestCase):
    def setUp(self):
        Contest.objects.create(contest_date="2022-10-01", active=False)
        Contest.objects.create(contest_date="2020-10-05", active=False)
        Contest.objects.create(contest_date="2023-09-03", active=True)

    def test_only_one_active_contest(self):
        self.assertEqual(Contest.objects.filter(active=False).count(), 2)
        first_contest = Contest.objects.first()
        first_contest.set_active()
        self.assertEqual(Contest.objects.filter(active=False).count(), 2)
        
